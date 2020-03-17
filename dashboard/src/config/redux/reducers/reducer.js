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
    default:
      return state
  }
}
export default reducer;
