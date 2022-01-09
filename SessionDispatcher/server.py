import psycopg2
import json
from jsonrpc import JSONRPCResponseManager, dispatcher
from flask import Flask, Response, request
from flask_cors import CORS

    
app = Flask(__name__)
CORS(app, supports_credentials=True)


def init_db():
    with open('C:\\Users\\Max\\Desktop\\PSU\\TRRP\\SiGame\\SessionDispatcher\\credentials.json', 'r') as credentials: 
        settings = json.loads(credentials.read())
    connection = psycopg2.connect(
        database=settings['DATABASE_STORAGE'],
        user=settings['DATABASE_USER'],
        password=settings['DATABASE_PASSWORD'],
        host=settings['DATABASE_HOST'],
        port=settings['DATABASE_PORT']
    )
    return connection


@dispatcher.add_method
def add_session(**kwargs):
    connection = init_db()
    ip = kwargs['ip']

    cursor = connection.cursor()
    cursor.execute(
    "INSERT INTO sessions (ip) VALUES (%s)", (ip),
    )
    connection.commit()
    connection.close()


@dispatcher.add_method
def delete_session(**kwargs):
    connection = init_db()
    ip = kwargs['ip']

    cursor = connection.cursor()
    cursor.execute(
    "DELETE FROM sessions WHERE ip = %s", (ip),
    )
    connection.commit() 
    connection.close()


@dispatcher.add_method
def get_sessions():
    connection = init_db()
    
    cursor = connection.cursor()

    cursor.execute("SELECT distinct ip FROM sessions;")
    return [row[0] for row in cursor.fetchall()]


@app.route('/jsonrpc', methods=['POST'])
def application():
    response = JSONRPCResponseManager.handle(json.dumps(request.json).encode('UTF-8'), dispatcher)
    return Response(response.json, mimetype='application/json')


if __name__ == '__main__':
    app.run('localhost', 50051, debug=True)