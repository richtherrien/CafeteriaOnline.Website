import React from 'react'
import { NavLink } from 'react-router-dom'

const SignedOutLinks  = () => {
    return(
        <div className="absolute top-0 right-0">
            <NavLink to='/signin' className="inline-block text-sm px-4 py-2 leading-none border rounded text-white border-white hover:border-transparent hover:text-teal-500 hover:bg-black mt-8 mr-4">Sign In</NavLink>
        </div>
    )
}

export default SignedOutLinks