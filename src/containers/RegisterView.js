import React from 'react';
import * as UserActions from '../actions/userActions';
import RegisterForm from '../components/RegisterForm';

class RegisterView extends React.Component {
  constructor(props){
    super (props);
    this.state = {
      user: {
        FirstName: "",
        LastName: "",
        Email: "",
        Password: "",
        ConfirmPassword: ""
      }
    }
    this.updateUserState = this.updateUserState.bind(this);
    this.registerUser = this.registerUser.bind(this);
  }
  updateUserState (e){
    const field = e.target.name;
    let user = this.state.user;
    user[field] = e.target.value;
    return this.setState({user: user});
  }
  registerUser (e){
    e.preventDefault();
    UserActions.registerUser(this.state.user)
    .then(user=>{
      console.log("this is the user", user);
      this.setState({
        user: {
          FirstName: "",
          LastName: "",
          Email: "",
          Password: "",
          ConfirmPassword: ""
        }
      })
    })
  }
  render(){
    return (
      <div>
        <RegisterForm
          onChange={this.updateUserState}
          onSubmit={this.registerUser}
          user={this.state.user}
        />
      </div>
    )
  }
}

export default RegisterView;
