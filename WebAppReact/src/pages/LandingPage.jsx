import React from "react";
import "./LandingPage.scss";
//import HelloForm from "../components/HelloForm";
import LoginForm from "../components/LoginForm";

class LandingPage extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            form: <LoginForm />
        };
    }

    render() {
        return(
            <main>
                {this.state.form}
            </main>
        );
    }
}

export default LandingPage;
