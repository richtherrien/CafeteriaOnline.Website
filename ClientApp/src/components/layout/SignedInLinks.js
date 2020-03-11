import React from 'react'
import { NavLink } from 'react-router-dom'

const SignedInLinks  = () => {
    return(
        <ul className="right">
            <li><NavLink to='/'>View Orders</NavLink></li>
            <li><NavLink to='/'>Place Order</NavLink></li>
            <li><NavLink to='/' className='btn btn-floating pink lighten-1'>Modify Orders</NavLink></li>
        </ul>
    )
}

export default SignedInLinks