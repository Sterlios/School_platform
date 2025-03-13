import './App.css';
import React from "react";
import Courses from "./Components/Courses.tsx";

function App() {
    return (
        <div className="Home">
            <h1>Добро пожаловать на School Platform</h1>
            <Courses />
        </div>
    );
}

export default App;