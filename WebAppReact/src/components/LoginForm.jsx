import React from "react";
import "./LoginForm.scss";

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
            <form onSubmit={this.handleSubmit}>
                <label for="username" className="gridRow1">Username:</label>
                <input
                    id="username"
                    className="gridRow1"
                    type="text"
                    value={this.state.username}
                    onChange={this.handleUsernameInputChange}
                />
                <label for="password" className="gridRow2">Password:</label>
                <input
                    id="password"
                    className="gridRow2"
                    type="password"
                    value={this.state.password}
                    onChange={this.handlePasswordInputChange}
                />
                <input type="submit" className="gridRow3" value="Login" />
            </form>
        );
    }
}

export default LoginForm;
