import React, {useState} from "react";
import "./LoginForm.scss";

const LoginForm = () => {
    const [username, setUsername] = useState("");
    const [password, setPassword] = useState("");

    const handleUsernameInputChange = (event) => {
        setUsername(event.target.value);
    }

    const handlePasswordInputChange = (event) => {
        setPassword(event.target.value);
    }

    const handleSubmit = (event) => {
        setUsername("");
        setPassword("");
        event.preventDefault();
    }

    return(
        <form className="LoginForm" onSubmit={handleSubmit}>
            <label htmlFor="username" className="LoginForm GridRow1">Username:</label>
            <input
                id="username"
                className="LoginForm GridRow1"
                type="text"
                value={username}
                onChange={handleUsernameInputChange}
            />
            <label htmlFor="password" className="LoginForm GridRow2">Password:</label>
            <input
                id="password"
                className="LoginForm GridRow2"
                type="password"
                value={password}
                onChange={handlePasswordInputChange}
            />
            <input type="submit" className="LoginForm" value="Login" />
        </form>
    );
}

export default LoginForm;
