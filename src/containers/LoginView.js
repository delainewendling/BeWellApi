import React, {PropTypes} from 'react';
import {connect} from 'react-redux';
import * as userActions from '../actions/userActions';
import LoginForm from '../components/LoginForm';
import {bindActionCreators} from 'redux';

class LoginView extends React.Component {
  constructor(props, context){
    super (props, context);
    this.state = {
      user: Object.assign({}, this.props.user),
      errors: {}
    };
    this.updateUserState = this.updateUserState.bind(this);
    this.loginUser = this.loginUser.bind(this);
  }
  updateUserState (e){
    const field = e.target.name;
    let user = this.state.user;
    user[field] = e.target.value;
    return this.setState({user: user});
  }
  loginUser (e){
    e.preventDefault();
    this.props.actions.loginUser(this.state.user);
    //this.context.router.push('/menu');
  }
  render(){
    return (
      <div>
        <LoginForm
          onChange={this.updateUserState}
          onSubmit={this.loginUser}
          user={this.state.user}
        />
      </div>
    )
  }
}

LoginView.propTypes = {
  user: PropTypes.object.isRequired,
  actions: PropTypes.object.isRequired
};
//context is basically a global variable. We should generally avoid this but router and redux are ok.
LoginView.contextTypes = {
  router: PropTypes.object
}

const mapStateToProps = (state)=> ({user: state.user});

const mapDispatchToProps = (dispatch) => ({actions: bindActionCreators(userActions, dispatch)});


export default connect(mapStateToProps, mapDispatchToProps)(LoginView);
