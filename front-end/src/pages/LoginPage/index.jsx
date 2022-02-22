import React, { useState } from "react";
import "./styles.css"

const LoginPage = () => {

    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");

    var dados = {
        email: email,
        senha: password
    }

    const handleSubmit = (e) => {
        e.preventDefault();
        dados.email = email;
        dados.senha = password;
        var json = JSON.stringify(dados);
        console.log("aaa", json)
    };

    return (
        <>
            <div id="login">
                <h1 className="title">Login do Sistema</h1>
                <form className="form" onSubmit={handleSubmit}>
                    <div className="field">
                        <label htmlFor="email">Email</label>
                        <input 
                        type="email" 
                        name="email" 
                        id="email" 
                        value={email} 
                        onChange={(e) => setEmail(e.target.value)}/>
                    </div>
                    <div className="field">
                        <label htmlFor="password">Senha</label>
                        <input 
                        type="password" 
                        name="password" 
                        id="password"
                        value={password}
                        onChange={(e) => setPassword(e.target.value)}/>
                    </div>
                    <div className="actions">
                        <button type="submit" >Entrar</button>
                    </div>
                </form>
            </div>
        </>
    );
};

export default LoginPage;