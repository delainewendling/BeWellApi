import {combineReducers} from 'redux';
import ajaxCallsInProgress from './ajaxStatusReducer';
import users from './userReducer';

const rootReducer = combineReducers({
  users,
  ajaxCallsInProgress
});
export default rootReducer;
