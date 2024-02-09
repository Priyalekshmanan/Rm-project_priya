import React, { useState } from 'react';
import './Lstyle.css';

const Login= () => {
  const [isLoginForm, setIsLoginForm] = useState(true);

  const handleFormChange = () => {
    setIsLoginForm(!isLoginForm);
  
  };
//   const img=[
//     {
//    id:1,
//    img:[frontImg]

//   },
//   {
//     id:2,
//     img:[backImg]
 
//    }
// ]

  return (
    
    <div className='contact-page'>
        <header className='height-75'>
            <div className='container h-100 d-flex flex-column align-items-center justify-content-center text-light'>
                <h1 className='text-center fw-semibold'>Login</h1>
                <p className='text-center w-75 mb-5'>Lorem ipsum, dolor sit amet consectetur adipisicing elit. Vitae pariatur qui quos aspernatur, voluptatem autem possimus esse quo consequatur omnis, soluta consectetur ullam ipsum cum!</p>
            </div>
        </header>
        <div className='bg-dark text-light p-5'>
            <div className='container'>
            <div className='containerlog'>
                <h2 className='text-center mb-5'></h2>
                <input type="checkbox" id="flip" onChange={handleFormChange} />
     
     <div className="cover">
       <div className="front">
         {/* <img src="../../utiles/images/frontImg.jpg" alt="Front Image" /> */}
         <div className="text">
           <span className="text-1">Every new friend is a <br /> new adventure</span>
           <span className="text-2">Let's get connected</span>
         </div>
       </div>
       <div className="back backImg">
         {/* <img src="images/backImg.jpg" alt="Back Image" className="backImg" /> */}
         <div className="text">
           {/* <span className="text-1">Complete miles of journey <br /> with one step</span>
           <span className="text-2">Let's get started</span> */}
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
    
    {/* <div className="container"> */}
     
      </div>
    </div>
    </div>
  );
};

export default Login;