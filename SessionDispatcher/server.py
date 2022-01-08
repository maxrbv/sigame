from concurrent import futures
import logging
import grpc
import sessions_pb2
import sessions_pb2_grpc
import psycopg2
import json


class SesionDispactherServicer(sessions_pb2_grpc.SesionDispactherServicer):
    def InitDB(self):
        with open('credentials.json', 'r') as credentials: 
            settings = json.loads(credentials.read())
        connection = psycopg2.connect(
            database=settings['DATABASE_STORAGE'],
            user=settings['DATABASE_USER'],
            password=settings['DATABASE_PASSWORD'],
            host=settings['DATABASE_HOST'],
            port=settings['DATABASE_PORT']
        )
        return connection


    def AddSession(self, request, context):
        connection = self.InitDB()
        ip = request.ip

        cursor = connection.cursor()
        cursor.execute(
        "INSERT INTO sessions (ip) VALUES (%s)", (ip),
        )
        connection.commit()
        connection.close()


    def DeleteSession(self, request, context):
        connection = self.InitDB()
        ip = request.ip

        cursor = connection.cursor()
        cursor.execute(
        "DELETE FROM sessions WHERE ip = %s", (ip),
        )
        connection.commit() 
        connection.close()
    

    def GetSessions(self, request, context):
        connection = self.InitDB()
        
        cursor = connection.cursor()

        for ip in cursor.fetchall("SELECT ip FROM sessions"):
            yield ip
        connection.close()


def serve():
    server = grpc.server(futures.ThreadPoolExecutor(max_workers=10))
    sessions_pb2_grpc.add_SesionDispactherServicer_to_server(SesionDispactherServicer(), server)
    server.add_insecure_port('[::]:50051')
    server.start()
    server.wait_for_termination()


if __name__ == '__main__':
    logging.basicConfig()
    serve()
    # так и не понял, получилось запустить или нет