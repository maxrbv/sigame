from concurrent import futures
import logging
import grpc
import sessions_pb2
import sessions_pb2_grpc
import psycopg2
import json
import sqlite3


class SessionsDispatcherServicer(sessions_pb2_grpc.SessionsDispatcherServicer):
    def InitDB(self):
        connection = sqlite3.connect(r'C:\Users\Max\Desktop\PSU\TRRP\sigame\db.db')
        return connection


    def AddSession(self, request, context):
        connection = self.InitDB()
        ip = request.ip

        cursor = connection.cursor()
        cursor.execute(
        "INSERT INTO sessions (ip) VALUES (?)", (ip,),
        )
        connection.commit()
        connection.close()
        
        return sessions_pb2.Reply(status = 1)


    def DeleteSession(self, request, context):
        connection = self.InitDB()
        ip = request.ip

        cursor = connection.cursor()
        cursor.execute(
        "DELETE FROM sessions WHERE ip = ?", (ip,),
        )
        connection.commit() 
        connection.close()
        return sessions_pb2.Reply(status = 1)
    

    def GetSessions(self, request, context):
        connection = self.InitDB()
        
        cursor = connection.cursor()
        cursor.execute("SELECT ip FROM sessions")
        for ip in cursor.fetchall():
            yield sessions_pb2.Session(ip=ip[0])
        connection.close()


def serve():
    server = grpc.server(futures.ThreadPoolExecutor(max_workers=10))
    sessions_pb2_grpc.add_SessionsDispatcherServicer_to_server(SessionsDispatcherServicer(), server)
    print('Server starting')
    server.add_insecure_port('[::]:50051')
    server.start()
    print('Server started')
    server.wait_for_termination()


if __name__ == '__main__':
    logging.basicConfig()
    serve()