import React, {useState} from 'react';
import "./LandingPage.scss";
import HelloForm from "../components/HelloForm";
import LoginForm from "../components/LoginForm";

const LandingPage = () => {
    const handleHelloSelected = () => {
        setForm("HelloForm");
    }

    const handleRegisterSelected = () => {
    }

    const handleLoginSelected = () => {
        setForm("LoginForm");
    }

    const [formName, setForm] = useState("HelloForm");

    const forms = {
        "HelloForm": <HelloForm onRegisterSelected={handleRegisterSelected} onLoginSelected={handleLoginSelected} />,
        "LoginForm": <LoginForm />
    };

    return(
        <main>
            {forms[formName]}
        </main>
    );
}

export default LandingPage;
