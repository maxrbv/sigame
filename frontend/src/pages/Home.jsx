import React, {useState} from "react"
import {useAsync} from "react-use"
import { SessionDispatcherClient } from "../SessionDispatcher"

const Home = () => {
    const [Sessions, setSessions] = useState([])
    const client = new SessionDispatcherClient('http://localhost:50051')
    const state = useAsync(async () => {
        const sessions = await client.get_sessions()
        setSessions(sessions)  
    })
    return (state.loading?<div>Loading...</div>:
        <div>
            {Sessions.map(item => <p>{item}</p>)}
            {/* <button onClick={createSession}>Создать сессию</button> */}
            {/* <button onClick={getSessions}>Обновить сессии</button> */}
        </div>
      );
}

export default Home;