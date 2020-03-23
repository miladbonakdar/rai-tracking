const initialState = {
  loading: false
}
const reducer = (state = initialState, action) => {
  switch (action.type) {
    case 'SHOW_LOADING': {
      return{
        ...state,
        loading: action.loading
      }
    }
    case 'USER_AUTH': {
      return {
        ...state,
        user: action.user
      }
    }

    default:
      return state
  }
}
export default reducer;
