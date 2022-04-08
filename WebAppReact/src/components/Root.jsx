import React from "react";
import "./Root.css";
import LoginForm from "./LoginForm";

function Root() {
    return (
        <>
            <header className="Root RootHeader">
                <h1 className="Root RootHeaderTitle">Login</h1>
            </header>
            <main className="Root RootMain">
                <LoginForm/>
            </main>
        </>
    );
}

export default Root;
