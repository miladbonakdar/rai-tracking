const initialState = {
  loading: false,
  token: localStorage.getItem('userToken') || null,
  user: localStorage.getItem('user') ? localStorage.getItem('user') : 'user'
}
const reducer = (state = initialState, action) => {
  switch (action.type) {
    case 'SHOW_LOADING': {
      return{
        ...state,
        loading: action.loading
      }
    }
    case 'SET_USER': {
      return {
        ...state,
        user: action.user
      }
    }
    case 'SET_TOKEN': {
      return {
        ...state,
        token: action.token
      }
    }

    default:
      return state
  }
}
export default reducer;
