import * as types from '../actions/actionTypes';
import initialState from './initialState';

export default function userReducer(state = initialState.user, action){
  switch(action.type){
    //What the ES6 spread operator does is return a new instance of the state array. Then you can use Object.assign to create a deep copy of the array with a new item.
    case types.REGISTER_USER_SUCCESS:
      return "Registered successfully!";
    case types.LOGIN_USER_SUCCESS:
      return [
        ...state,
        Object.assign({}, action.user)
      ]
    default:
      return state;
  }
}
