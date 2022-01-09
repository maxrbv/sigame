import axios from 'axios'

export class SessionDispatcherClient{
    constructor(host){
        this.data = {'method':null, 'params':null, 'jsonrpc':'2.0', 'id':0}
        this.client = axios.create({baseURL:host, withCredentials:true})
    }
    async get_sessions(){
        const response = await this.client.post('/jsonrpc', {...this.data, 'method':'get_sessions'})
        return response['data']['result']
    }
}