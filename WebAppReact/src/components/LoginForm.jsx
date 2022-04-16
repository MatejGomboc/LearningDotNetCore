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
        this.setState(
            {
                username: "",
                password: ""
            }
        );

        event.preventDefault();
    }

    render() {
        return(
            <form className="LoginForm" onSubmit={this.handleSubmit}>
                <label htmlFor="username" className="LoginForm GridRow1">Username:</label>
                <input
                    id="username"
                    className="LoginForm GridRow1"
                    type="text"
                    value={this.state.username}
                    onChange={this.handleUsernameInputChange}
                />
                <label htmlFor="password" className="LoginForm GridRow2">Password:</label>
                <input
                    id="password"
                    className="LoginForm GridRow2"
                    type="password"
                    value={this.state.password}
                    onChange={this.handlePasswordInputChange}
                />
                <input type="submit" className="LoginForm" value="Login" />
            </form>
        );
    }
}

export default LoginForm;
