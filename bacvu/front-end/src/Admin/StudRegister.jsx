import axios from 'axios'
import React, { useEffect, useState } from 'react'

export default function StudRegister() {
    const [id, setId] = useState("")
  const [fname, setFname] = useState("")
  const [lname, setLname] = useState("")
  const [email, setEmail] = useState("")
  const [number, setNumber] = useState("")
  const [dob, setDob] = useState("")
  const [std, setStd] = useState("")
  const [section, setSection] = useState("")
  const [gender, setGender] = useState("")
  const [errors, setErrors] = useState({}); // State variable for errors


  function Reg(){
    const errors = {};
    if (!id) {
        errors.id = 'Teacher Id is required';
    }
    if (!fname) {
        errors.fname = 'First Name is required';
    }
    if (!lname) {
        errors.lname = 'Last Name is required';
    }
    if (!dob) {
      errors.dob = 'Dob is required';
  }
    if (!email) {
        errors.email = 'Email address is required';
    }
    if (!number) {
        errors.number = 'Phone number is required';
    }
    if (!std) {
        errors.std = 'Class Std is required';
    }
    if (!gender) {
      errors.gender = 'Gender is required';
  }
  if (!section) {
    errors.section = 'Section is required';
  }
  setErrors(errors);
  
  if (Object.keys(errors).length !== 0) {
      return;
  }
    let reg={
      id: id,
  fName: fname,
  lName: lname,
  gender:gender,
  eMail: email,
  number: number,
  dob:dob,
  clss: std,
  section: section
    }
    axios.post("http://localhost:5099/api/Student/AddStudent",reg)
    .then((response) => {
      console.log(response.data);
      alert("Registration successfully")
    })
    .catch((error) => console.log(error));
  }
  return (
    <div>
        <section class="h-100 bg-dark">
  <div class="container py-5 h-100">
    <div class="row d-flex justify-content-center align-items-center h-100">
      <div class="col">
        <div class="card card-registration my-4">
          <div class="row g-0">
            <div class="col-xl-6 d-none d-xl-block">
              <img src="https://mdbcdn.b-cdn.net/img/Photos/new-templates/bootstrap-registration/img4.webp"
                alt="Sample photo" class="img-fluid"
                style={{ borderTopLeftRadius: ".25rem", borderBottomLeftRadius: ".25rem" }}/>
            </div>
            <div class="col-xl-6">
              <div class="card-body p-md-5 text-black">
                <h3 class="mb-5 text-uppercase">Student Form</h3>

                <div class="row">


                <div class="form-outline mb-4">
                  <input type="text" id="form3Example9" class="form-control form-control-lg" value={id} onChange={(e)=>setId(e.target.value)}/>
                  <label class="form-label" for="form3Example9">Student Id</label>
                  {errors.id && <span className="error">{errors.id}</span>}
                </div>


                  <div class="col-md-6 mb-4">
                    <div class="form-outline">
                      <input type="text" id="form3Example1m" class="form-control form-control-lg" value={fname} onChange={(e)=>setFname(e.target.value)} />
                      <label class="form-label" for="form3Example1m">First name</label>
                      {errors.fname && <span className="error">{errors.fname}</span>}
                    </div>
                  </div>
                  <div class="col-md-6 mb-4">
                    <div class="form-outline">
                      <input type="text" id="form3Example1n" class="form-control form-control-lg" value={lname} onChange={(e)=>setLname(e.target.value)} />
                      <label class="form-label" for="form3Example1n">Last name</label>
                      {errors.lname && <span className="error">{errors.lname}</span>}
                    </div>
                  </div>

                  <div class="d-md-flex justify-content-start align-items-center mb-4 py-2">
                   <h6 class="mb-0 me-4">Gender: </h6>
                   {errors.gender && <span className="error">{errors.gender}</span>}
                      <div class="form-check form-check-inline mb-0 me-4">
                         <input class="form-check-input" type="radio" name="genderOptions" id="femaleGender"
                          value="female" onChange={(e)=>setGender(e.target.value)} />
                          <label class="form-check-label" for="femaleGender">Female</label>
                      </div>
                      <div class="form-check form-check-inline mb-0 me-4">
                       <input class="form-check-input" type="radio" name="genderOptions" id="maleGender"
                        value="male" onChange={(e)=>setGender(e.target.value)}  />
                       <label class="form-check-label" for="maleGender">Male</label>
                       </div>
                </div>

                <div class="form-outline mb-4">
                  <input type="date" id="form3Example9" class="form-control form-control-lg" value={dob} onChange={(e)=>setDob(e.target.value)}/>
                  <label class="form-label" for="form3Example9">Dob</label>
                  {errors.dob && <span className="error">{errors.dob}</span>}
                </div>
                  <div class="form-outline mb-4">
                  <input type="email" id="form3Example9" class="form-control form-control-lg" value={email} onChange={(e)=>setEmail(e.target.value)}/>
                  <label class="form-label" for="form3Example9">Email</label>
                  {errors.email && <span className="error">{errors.id}</span>}
                </div>
                <div class="form-outline mb-4">
                  <input type="tel" id="form3Example9" class="form-control form-control-lg" value={number} onChange={(e)=>setNumber(e.target.value)}/>
                  <label class="form-label" for="form3Example9">Mobile</label>
                </div>
                
                {/* <div class="form-outline mb-4">
                  <input type="text" id="form3Example9" class="form-control form-control-lg" value={std} onChange={(e)=>setStd(e.target.value)} />
                  <label class="form-label" for="form3Example9">Class</label>
                </div> */}
                <div class="form-outline mb-4">
                  <select className="form-control form-control-lg" value={std} onChange={e => setStd( e.target.value )} >
                    <option value="">Class</option>
                    <option value="Class A">Class A</option>
                    <option value="Class B">Class B</option>
                    <option value="Class C">Class C</option>
                  </select>
                </div>
                <div class="form-outline mb-4">
                  <input type="text" id="form3Example9" class="form-control form-control-lg" value={section} onChange={(e)=>setSection(e.target.value)}/>
                  <label class="form-label" for="form3Example9">Sectiion</label>
                </div>
                </div>
                <div class="d-flex justify-content-end pt-3">
                  <button type="button" class="btn btn-warning btn-lg ms-2" onClick={Reg}>Submit</button>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</section>
    </div>
  )
}
