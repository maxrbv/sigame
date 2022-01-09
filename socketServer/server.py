import socket
import asyncio
import json


def _get_message(socket):
    # Get message size
    size_data = socket.recv(4)
    size = int.from_bytes(size_data, byteorder='big')
    # Get all message
    message_data = socket.recv(size)
    message = json.loads(message_data.decode('utf-8'))
    return message


class Server:
    def __init__(self, addr, loop):
        self._loop = loop
        self._socket = socket.create_server(address=addr,
                                            family=socket.AF_INET,
                                            backlog=10)
        self._sessions = {}

    def run(self):
        self._loop.create_task(self._start_server())

    async def _start_server(self):
        while True:
            # Get client connection
            client_socket, client_address = self._socket.accept()

            print('Get connection from', client_address)
            # Get session name
            message = _get_message(client_socket)

            # Add client to session
            if self._sessions.get(message['session_name']) is None:
                self._sessions[message['session_name']] = [client_socket]
            else:
                self._sessions[message['session_name']].append(client_socket)

            # Listen messages from client
            self._loop.create_task(self._listen_client(client_socket, client_address, message['session_name']))

    async def _listen_client(self, socket, socket_address, session_name):
        while True:
            message = _get_message(socket)
            # Get sockets connected to session
            clients = self._sessions[session_name]
            for temp_socket in clients:
                if temp_socket != socket:
                    # Send message to other sockets in session
                    temp_socket.send(data=message)


if __name__ == '__main__':
    loop = asyncio.get_event_loop()
    server = Server(('localhost', 8000), loop)
    server.run()
    print('server started')
    loop.run_forever()
