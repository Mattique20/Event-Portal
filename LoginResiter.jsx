import React, { useState } from 'react'
import './LoginRegister.css'
import { FaUserAlt } from "react-icons/fa";
import { FaLock } from "react-icons/fa";
import { FaArrowCircleDown } from "react-icons/fa";
import { MdEmail } from "react-icons/md";
const LoginResiter = () => {
  
  const [action, setAction]= useState('');
  const registerLink=()=>{ setAction(' active'); };
  const loginLink=()=>{ setAction(''); };
    return (
    <div className={`wrapper${action}`}>
        <div className='form-box login'>
            <form action="">
                <h1>Login</h1>
                <div className='input-box'>
                    <input type='text' placeholder='Username' required/>
                    <FaUserAlt className='icon'/>
                </div>
                <div className='input-box'>
                    <input type='password' placeholder='password' required/>
                    <FaLock className='icon'/>
                </div>

                <div className="remember-forgot">
                    <label><input type='checkbox'/>Remember me</label>
                    <a href='#'> forgot password</a>
                </div>

                <button type='submit'>Login</button>
                <div className="register-link">
                    <p>Don't Have an Account? <a href="#" onClick={registerLink}>Register</a></p>
                </div>
            </form>
        </div>

        <div className='form-box Register'>
            <form action="">
                <h1>Registration</h1>
                <div className='input-box'>
                    <input type='text' placeholder='Username' required/>
                    <FaUserAlt className='icon'/>
                </div>
                <div className='input-box'>
                    <input type='email' placeholder='Email' required/>
                    <MdEmail className='icon'/>
                </div>

                <div className='input-box'>
                    <input type='password' placeholder='password' required/>
                    <FaLock className='icon'/>
                </div>

                <div className="input-box">
                    <select>
                        <option value="">Select Role</option>
                        <option value="faculty">Faculty</option>
                        <option value="student">Student</option>
                    </select>
                    <FaArrowCircleDown className='icon'/>
                 </div>

                <div className="remember-forgot">
                    <label><input type='checkbox'/>I hereby agree to terms and condition</label>
                </div>

                <button type='submit'>Register</button>
                <div className="register-link">
                    <p>Already Have an Account? <a href="#" onClick={loginLink}>Login</a></p>
                </div>
            </form>
        </div>
    </div>    
  );
}

export default LoginResiter;