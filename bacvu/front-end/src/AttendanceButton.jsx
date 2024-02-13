import React from 'react'
import { Link } from 'react-router-dom'

export default function AttendanceButton() {
  return (
    <div className='d-flex justify-content-around my-5'>
      <Link className="btn btn-primary"  role="button" to="./">
      Add Student
      </Link>
      
      <Link className="btn btn-primary"  role="button" to="view-all-student-attendance">
    View All
      </Link>
      
      <Link className="btn btn-primary"  role="button" to="all-student-attendance-record">
      All Record
      </Link>
      <Link className="btn btn-primary" role="button" to="student-attendance-record-by-id">
        Record By Id
      </Link>
    </div>
  )
}
