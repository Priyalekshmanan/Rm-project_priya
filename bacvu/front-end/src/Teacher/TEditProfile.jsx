import axios from 'axios';
import React, { useEffect, useState } from 'react'
import { useNavigate } from 'react-router-dom';

export default function TEditProfile() {
    const [email, setEmail] = useState("");
    const [phone, setPhone] = useState("");
    const [address, setAddress] = useState("");
    const [emailError, setEmailError] = useState("");
    const [phoneError, setPhoneError] = useState("");
    const [addressError, setAddressError] = useState("");
    const [teachers, setTeachers] = useState([]);
    const navigate = useNavigate();
    let userId = sessionStorage.getItem("uid");

    useEffect(() => {
        if (sessionStorage.getItem("token") != null) {
            console.log(sessionStorage.getItem("token"));
            const headers = {
                Authorization: `Bearer ${sessionStorage.getItem("token")}`,
            };
            axios
                .get("http://localhost:5099/api/Teacher/getTeachersByTheirId/" + userId, { headers })
                .then((res) => {
                    setTeachers(res.data);
                    console.log(res.data);
                    
                })
                
                .catch((error) => {
                    console.log(error);
                });
        } else {
            navigate("/login");
        }
    }, []);

    function validateEmail(email) {
        const re = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
        return re.test(String(email).toLowerCase());
    }

    function validatePhone(phone) {
        const re = /^\+91[0-9]{10}$/;
        return re.test(phone);
    }

    function validateAddress(address) {
        
        const re =/^[#.0-9a-zA-Z\s,-]+$/;
        return re.test(address);
    }

    function handleEmailChange(e) {
        setEmail(e.target.value);
        if (!validateEmail(e.target.value)) {
            setEmailError("Please enter a valid email address.");
        } else {
            setEmailError("");
        }
    }

    function handlePhoneChange(e) {
        setPhone(e.target.value);
        if (!validatePhone(e.target.value)) {
            setPhoneError("Please enter a valid Indian phone number starting with +91.");
        } else {
            setPhoneError("");
        }
    }
    
    function Edit() {
        if (sessionStorage.getItem("token") != null) {
            console.log(sessionStorage.getItem("token"));
            const headers = {
              Authorization: `Bearer ${sessionStorage.getItem("token")}`,
            };
        if (validateEmail(email) && validatePhone(phone)) {
            let tcr = {
                dateOfBirth: teachers.dateOfBirth,
                teacherFirstName: teachers.teacherFirstName,
                teacherId:userId ,
                teacherLastName: teachers.teacherLastName,
                teacherAddress: address,
                teacherGender: teachers.teacherGender,
                teacherEmail: email,
                teacherPhone: phone,
                teacherSubjectTaught:teachers.teacherSubjectTaught
            };
            console.log(tcr);

            axios
                .put("http://localhost:5099/api/Teacher/updatingTeachersById", tcr,{headers})
                .then((res) => {
                    console.log(res.data);
                  
                    alert("Teacher Details Updated");

                })

                .catch((error) => {
                    console.error("Error editing profile:", error);
                });
        } else {
            alert("Please correct the errors in the form.");
        }
    }
    else{
        navigate("/login")
    }
    }

  return (
    <div className="main-content position-relative max-height-vh-100 h-100 border-radius-lg">
            <div className="edit-profile-form">
                <h1>Edit Profile</h1>
                <form>
                    <div className="form-group">
                        <label>Email:</label>
                        <input type="email" className="form-control" value={email} onChange={handleEmailChange} />
                        {emailError && <small className="text-danger">{emailError}</small>}
                    </div>
                    <div className="form-group">
                        <label>Phone:</label>
                        <input type="tel" className="form-control" value={phone} onChange={handlePhoneChange} />
                        {phoneError && <small className="text-danger">{phoneError}</small>}
                    </div>
                    <div className="form-group">
                        <label>Address:</label>
                        <input type="text" className="form-control"  onChange={(e)=>setAddress(e.target.value)}/>
                     
                    </div>
                    <button type="button" className="btn btn-primary" onClick={Edit}>
                        Submit
                    </button>
                </form>
            </div>
        </div>
  )
}
