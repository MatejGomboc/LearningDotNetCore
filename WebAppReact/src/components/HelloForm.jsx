import React from "react";
import "./HelloForm.scss";

class HelloForm extends React.Component {
    handleClickRegister = (event) => {
    }

    handleClickLogin = (event) => {
    }

    render() {
        return(
            <div className="HelloForm">
                <h1 className="HelloForm GridRow1">Hello!</h1>
                <button className="HelloForm GridRow2" onClick={this.handleClickRegister}> Register </button>
                <button className="HelloForm GridRow3" onClick={this.handleClickLogin}> Login </button>
            </div>
        );
    }
}

export default HelloForm;
