import React from 'react';

const FormInput = ({type, name, label, onChange, value})=>{
  return (
    <div className="form-group">
      <label htmlFor={name}>{label}</label>
    <div className='field'>
      <input
        type={type}
        name={name}
        className="form-control"
        placeholder={label}
        value={value}
        onChange={onChange}/>
      </div>
    </div>
  )
}

export default FormInput;
