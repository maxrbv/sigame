import React from "react"

const Home = () => {

    const getSessions= () =>{

    }

    const createSession = () =>{

    }

    return (
        <div>
            <button onClick={createSession}>Создать сессию</button>
            <button onClick={getSessions}>Обновить сессии</button>
        </div>
      );
}

export default Home;