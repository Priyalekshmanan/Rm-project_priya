import React from 'react'
import { Link } from 'react-router-dom'

import './Lstyle.css'

export default function SignUpPage() {

    return (
        <div className="text-center m-5-auto">
            <h2>Join us</h2>
            <h5>Create your personal account</h5>
            <form action="/home">
                <p>
                    <label>Username</label><br/>
                    <input type="text" name="first_name" required />
                </p>
                <p>
                    <label>Email address</label><br/>
                    <input type="email" name="email" required />
                </p>
                <p>
                    <label>Password</label><br/>
                    <input type="password" name="password" requiredc />
                </p>
                <p>
                    <input type="checkbox" name="checkbox" id="checkbox" required /> <span>I agree all statements in <a href="https://google.com" target="_blank" rel="noopener noreferrer">terms of service</a></span>.
                </p>
                <p>
                    <button id="sub_btn" type="submit">Register</button>
                </p>
            </form>
            <footer>
                <p><Link to="/">Back to Homepage</Link>.</p>
            </footer>
        </div>
    )

}


    
<div className="container">
<input type="checkbox" id="flip" onChange={handleFormChange} />

<div className="cover">
  <div className="front">
   
    <div className="text">
      <span className="text-1">Every new friend is a <br /> new adventure</span>
      <span className="text-2">Let's get connected</span>
    </div>
  </div>
  <div className="back backImg">
   
    <div className="text">
      <span className="text-1">Complete miles of journey <br /> with one step</span>
      <span className="text-2">Let's get started</span>
    </div>
  </div>
</div>
<div className="forms">
  <div className="form-content">
    <div className={isLoginForm ? "login-form active-form" : "login-form"}>
      <div className="title">Login</div>
      <form action="#">
        <div className="input-boxes">
          <div className="input-box">
            <i className="fas fa-envelope"></i>
            <input type="text" placeholder="Enter your email" required />
          </div>
          <div className="input-box">
            <i className="fas fa-lock"></i>
            <input type="password" placeholder="Enter your password" required />
          </div>
          <div className="text">
            <a href="#">Forgot password?</a>
          </div>
          <div className="button input-box">
            <input type="submit" value="Submit" />
          </div>
          <div className="text sign-up-text">Don't have an account? <label htmlFor="flip">Sigup now</label></div>
        </div>
      </form>
    </div>
    <div className={isLoginForm ? "signup-form" : "signup-form active-form"}>
      <div className="title">Signup</div>
      <form action="#">
        <div className="input-boxes">
          <div className="input-box">
            <i className="fas fa-user"></i>
            <input type="text" placeholder="Enter your name" required />
          </div>
          <div className="input-box">
            <i className="fas fa-envelope"></i>
            <input type="text" placeholder="Enter your email" required />
          </div>
          <div className="input-box">
            <i className="fas fa-lock"></i>
            <input type="password" placeholder="Enter your password" required />
          </div>
          <div className="button input-box">
            <input type="submit" value="Submit" />
          </div>
          <div className="text sign-up-text">Already have an account? <label htmlFor="flip">Login now</label></div>
        </div>
      </form>
    </div>
  </div>
</div>
</div>
