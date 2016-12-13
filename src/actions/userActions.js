import * as types from './actionTypes';
import * as userApi from '../apiMethods/UserMethods';
import {beginAjaxCall} from './ajaxStatusActions';

export function loginUserSuccess(user){
  return { type: types.LOGIN_USER_SUCCESS, user};
}

//If the response 
export function registerUser(user) {
  return dispatch =>{
    dispatch(beginAjaxCall());
    return userApi.registerUser(user)
    .then(userResponse =>{
        dispatch(loginUserSuccess(userResponse));
    })
    .catch(error =>{
      throw(error);
    })
  }
}

export function loginUser(user) {
  return dispatch =>{
    dispatch(beginAjaxCall());
    return userApi.loginUser(user)
    .then(userResponse =>{
      dispatch(loginUserSuccess(userResponse));
    })
    .catch(error =>{
      throw(error);
    })
  }
}
