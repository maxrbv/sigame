
const grpc = require("@grpc/grpc-js")
const protoLoader = require("@grpc/proto-loader")

const PROTO_PATH = "./consumer/sessions.proto"

const options = {
    keepCase: true,
    longs: String,
    enums: String,
    defaults: true,
    oneofs: true,
}

const packageDefinition = protoLoader.loadSync(PROTO_PATH, options)

const SessionsDispatcher = grpc.loadPackageDefinition(packageDefinition).SessionsDispatcher

export default SessionsDispatcher;