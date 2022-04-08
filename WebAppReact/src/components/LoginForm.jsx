import React from "react";
import "./LoginForm.css";

class LoginForm extends React.Component {
    constructor(props) {
        super(props);

        this.state = {
            password: "",
            username: ""
        };

        this.handleUsernameInputChange = this.handleUsernameInputChange.bind(this);
        this.handlePasswordInputChange = this.handlePasswordInputChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
    }

    handleUsernameInputChange(event) {
        this.setState((prevState) => {
                return {
                    username: event.target.value,
                    password: prevState.password
                };
            }
        );
    }

    handlePasswordInputChange(event) {
        this.setState((prevState) => {
                return {
                    username: prevState.username,
                    password: event.target.value
                };
            }
        );
    }

    handleSubmit(event) {
        alert(`username: ${this.state.username}; password: ${this.state.password};`);

        this.setState(
            {
                username: "",
                password: ""
            }
        );

        event.preventDefault();
    }

    render() {
        return (
            <form className="LoginForm" onSubmit={this.handleSubmit}>
                <label className="LoginFormLabel LoginFormRow1">Username:</label>
                <input
                    className="LoginFormInput LoginFormRow1"
                    type="text"
                    value={this.state.username}
                    onChange={this.handleUsernameInputChange}
                />
                <label className="LoginFormLabel LoginFormRow2">Password:</label>
                <input
                    className="LoginFormInput LoginFormRow2"
                    type="password"
                    value={this.state.password}
                    onChange={this.handlePasswordInputChange}
                />
                <input className="LoginFormButton" type="submit" value="Login" />
            </form>
        );
    }
}

export default LoginForm;
