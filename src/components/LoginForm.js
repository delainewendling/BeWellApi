import React from 'react';
import FormInput from './FormInput';

const LoginForm = ({onChange, onSubmit, user})=> {
  return (
    <form>
      <h1> Login </h1>
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

      <input
        type="submit"
        className="btn btn-primary"
        onClick={onSubmit}/>
    </form>
  )
}

export default LoginForm;
