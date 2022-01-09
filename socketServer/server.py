import socket
import asyncio
import json


def _get_message(socket):
    # Get message size
    size_data = socket.recv(bufsize=4)
    size = int.from_bytes(size_data, byteorder='big')
    # Get all message
    message_data = socket.recv(bufsize=size)
    message = json.loads(message_data.decode('utf-8'))
    return message


class Server:
    def __init__(self, addr):
        self._loop = asyncio.get_event_loop()
        self._socket = socket.create_server(address=addr,
                                            family=socket.AF_INET,
                                            backlog=10)
        self._sessions = []

    def run(self):
        self._loop.create_task(self._start_server())

    async def _start_server(self):
        while True:
            # Get client connection
            client_socket, client_address = self._socket.accept()

            # Get session name
            message = _get_message(client_socket)

            # Add client to session
            self._sessions[message['session_name']].append(client_address)

            # Listen messages from client
            self._loop.create_task(self._listen_client(client_socket, message['session_name']))

    async def _listen_client(self, socket, session_name):
        while True:
            message = _get_message(socket)
            if message['type'] == 'open_question':
                pass


if __name__ == '__main__':
    server = Server(('localhost', 8000))
    server.run()
