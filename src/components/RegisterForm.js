import React, {PropTypes} from 'react';
import FormInput from './FormInput';

const RegisterForm = ({onChange, onSubmit, user})=> {
  return (
    <form>
      <h1> Register </h1>
      <FormInput
        type="text"
        name="FirstName"
        label="First Name"
        value={user.FirstName}
        onChange={onChange}/>

      <FormInput
        type="text"
        name="LastName"
        label="Last Name"
        value={user.LastName}
        onChange={onChange}/>

      <FormInput
        type="email"
        name="Email"
        label="Email"
        value={user.Email}
        onChange={onChange}/>

      <FormInput
        type="password"
        name="Password"
        label="Password"
        value={user.Password}
        onChange={onChange}/>

      <FormInput
        type="password"
        name="ConfirmPassword"
        label="Confirm Password"
        value={user.ConfirmPassword}
        onChange={onChange}/>

      <input
        type="submit"
        className="btn btn-primary"
        onClick={onSubmit}/>
    </form>
  )
}

RegisterForm.propTypes = {
  type: PropTypes.string.isRequired,
  onChange: PropTypes.func.isRequired,
  name: PropTypes.string.isRequired
};


export default RegisterForm;
