import React, { Component } from 'react'
import { NavLink } from 'react-router-dom'

export default class Signin extends Component {
    state = {
        username: '',
        password: ''
    }
    
    handleChange = (e) => {
        this.setState({
            [e.target.id]: e.target.value
        })
    }

    handleSubmit = (e) => {
        e.preventDefault();
        console.log(this.state);
    }

    render() {
        return (
            <div>
                 <div className="absolute top-0 right-0">
                    <NavLink to='/' className="inline-block text-sm px-4 py-2 leading-none border rounded text-white border-white hover:border-transparent hover:text-teal-500 hover:bg-black mt-8 mr-4">Back</NavLink>
                </div>
                <div className="container p-20">
                    <form onSubmit={this.handleSubmit} className="bg-teal-100 shadow-md rounded px-8 pt-6 pb-8 mb-4">
                        <h1 className="grey-text text-darken-3 mb-4">Sign In</h1>
                        {/*Email/Employee ID input */}
                        <div className="input-field">
                            <label className="block text-gray-700 text-xl font-bold mb-2" htmlFor="username">Email/Employee ID</label>
                            <input className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline" id="username" type="email" placeholder="Email/Employee ID" onChange={this.handleChange}/>
                        </div>
                        {/*Password input */}
                        <div className="input-field">
                            <label className="block text-gray-700 text-xl font-bold mb-2 mt-4" htmlFor="password">Password</label>
                            <input className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline" id="password" type="password" placeholder="Password" onChange={this.handleChange}/>
                        </div>
                        {/*Sign In button */}
                        <div className="input-field">
                            <button className="text-xl bg-orange-500 hover:bg-orange-300 text-white font-bold py-2 px-4 border border-blue-700 rounded mt-10">
                                Sign In
                            </button>
                        </div>
                    </form>
                </div>
            </div>
        )
    }
}