import React, { Component } from 'react'
import { NavLink } from 'react-router-dom'

export default class EmployeeRegistration extends Component {
    state = {
        FirstName: '',
        LastName: '',
        employeeID: '',
        employeeNumber: '',
        employeeEmail: '',
        CompanyCode: '',
        employeePassword: ''
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
                {/*Back button on NavBar */}
                <div className="absolute top-0 right-0">
                    <NavLink to='/' className="inline-block text-sm px-4 py-2 leading-none border rounded text-white border-white hover:border-transparent hover:text-teal-500 hover:bg-black mt-8 mr-4">Back</NavLink>
                </div>
                
                <h1 className="text-gray-900 text-center text-darken-3 mt-3">Employee Registration</h1>
                
                <div className="flex p-3">
                {/*Form to input information */}
                    <form onSubmit={this.handleSubmit} className="bg-green-300 border-2 border-green-800 shadow-lg rounded p-4 m-auto max-w-6xl">
                        <h5 className="text-gray-600 text-sm mb-4">Please provide all following required information to register yourself with us</h5>
                        <div className="grid grid-cols-2 gap-10">
                            <div className="col-span-1">{/*Employee Name */}
                                <label className="block text-gray-900 text-2xl font-bold mb-2" htmlFor="employeeName">Employee Name</label>
                                 <div className="grid grid-cols-3 gap-3 mt-2">
                                    <div className="col-span1">{/*First Name */}
                                        <label htmlFor="FirstName"></label>
                                        <input className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline" id="FirstName" type="text" placeholder="John" onChange={this.handleChange} />
                                    </div>
                                    <div className="col-span1">{/*Last Name */}
                                        <label htmlFor="LastName"></label>
                                        <input className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline" id="LastName" type="text" placeholder="Doe" onChange={this.handleChange} />
                                    </div>
                                </div>
                            </div>
                            <div className="col-span-1">{/*Employee Phone Number */}
                                <label className="block text-gray-900 text-2xl font-bold mb-2" htmlFor="employeeNumber">Employee Phone Number</label>
                                <input className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline" id="employeeNumber" type="text" placeholder="1234567891" onChange={this.handleChange}/>
                            </div>
                            <div className="col-span-1">{/*Employee Number */}
                                <label className="block text-gray-900 text-2xl font-bold mb-2" htmlFor="employeeID">Employee Number</label>
                                <input className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline" id="employeeID" type="text" placeholder="1234567891" onChange={this.handleChange}/>
                            </div>
                            <div className="col-span-1">{/*Employee Email */}
                                <label className="block text-gray-900 text-2xl font-bold mb-2" htmlFor="employeeEmail">Employee Email</label>
                                <input className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline" id="employeeEmail" type="email" placeholder="johndoe@ryerson.ca" onChange={this.handleChange}/>
                            </div>
                            <div className="col-span-1"></div>
                            <div className="col-span-1">{/*Employee Password */}
                                <label className="block text-gray-900 text-2xl font-bold mb-2" htmlFor="employeePassword">Employee Password</label>
                                <input className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline" id="employeePassword" type="password" placeholder="Please select a password between 8-16 characters" onChange={this.handleChange}/>
                            </div>
                            <div className="col-span-2 text-center"> {/*Register button */}
                                <button className="text-xl bg-orange-500 hover:bg-orange-300 text-white font-bold py-2 px-4 border border-blue-700 rounded m-auto">
                                    Register!
                                </button>
                            </div>
                        </div>
                    </form>
                </div>
            </div>
        )
    }
}
