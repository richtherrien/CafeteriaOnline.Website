import React, { Component } from 'react'
import { NavLink } from 'react-router-dom'

export default class CompanyRegistration extends Component {
    state = {
        companyName: '',
        companyStreetAddress: '',
        companyCity: '',
        companyProvince: '',
        companyPostalCode: '',
        companyPhone: '',
        companyContactName: '',
        companyContactEmail: '',
        companyContactPhone: '',
        companyPassword: ''
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
                
                <h1 className="text-gray-900 text-center text-darken-3 mt-3">Company Registration</h1>
                
                <div className="flex p-3">
                {/*Form to input information */}
                    <form onSubmit={this.handleSubmit} className="bg-green-300 border-2 border-green-800 shadow-lg rounded p-4 m-auto max-w-6xl">
                        <h5 className="text-gray-600 text-sm mb-4">Please provide all following required information to register your company with us</h5>
                        <div className="grid grid-cols-2 gap-10">
                            <div className="col-span-1">{/*Company Name */}
                                <label className="block text-gray-900 text-2xl font-bold mb-2" htmlFor="companyName">Company Name</label>
                                <input className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline" id="companyName" type="text" placeholder="Ryerson University" onChange={this.handleChange}/>
                            </div>
                            <div className="col-span-1">{/*Company Contact Name */}
                                <label className="block text-gray-900 text-2xl font-bold mb-2" htmlFor="companyContactName">Company Contact Name</label>
                                <input className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline" id="companyContactName" type="text" placeholder="John Doe" onChange={this.handleChange}/>
                            </div>
                            <div className="col-span-1">{/*Company Address */}
                                <div className="block text-gray-900 text-2xl font-bold mb-2">Company Address</div>
                                <label htmlFor="companyStreetAddress"></label>{/*Street Address */}
                                <input className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline" id="companyStreetAddress" type="text" placeholder="350 Victoria Street" onChange={this.handleChange}/>
                                <div className="grid grid-cols-3 gap-3 mt-2">
                                    <div className="col-span1">{/*City */}
                                        <label htmlFor="companyCity"></label>
                                        <input className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline" id="companyCity" type="text" placeholder="Toronto" onChange={this.handleChange}/>
                                    </div>
                                    <div className="col-span1">{/*Province */}
                                        <label htmlFor="companyProvince"></label>
                                        <input className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline" id="companyProvince" type="text" placeholder="Ontario" onChange={this.handleChange}/>
                                    </div>
                                    <div className="col-span1">{/*Postal Code */}
                                        <label htmlFor="companyPostalCode"></label>
                                        <input className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline" id="companyPostalCode" type="text" placeholder="M5B2K3" onChange={this.handleChange}/>
                                    </div>
                                </div>
                            </div>
                            <div className="col-span-1">{/*Company Contact Phone Number */}
                                <label className="block text-gray-900 text-2xl font-bold mb-2" htmlFor="companyContactPhone">Company Contact Phone Number</label>
                                <input className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline" id="companyContactPhone" type="text" placeholder="1234567891" onChange={this.handleChange}/>
                            </div>
                            <div className="col-span-1">{/*Company Phone Number */}
                                <label className="block text-gray-900 text-2xl font-bold mb-2" htmlFor="companyPhone">Company Phone Number</label>
                                <input className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline" id="companyPhone" type="text" placeholder="1234567891" onChange={this.handleChange}/>
                            </div>
                            <div className="col-span-1">{/*Company Contact Email */}
                                <label className="block text-gray-900 text-2xl font-bold mb-2" htmlFor="companyContactEmail">Company Contact Email</label>
                                <input className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline" id="companyContactEmail" type="email" placeholder="johndoe@ryerson.ca" onChange={this.handleChange}/>
                            </div>
                            <div className="col-span-1"></div>
                            <div className="col-span-1">{/*Company Password */}
                                <label className="block text-gray-900 text-2xl font-bold mb-2" htmlFor="companyPassword">Company Password</label>
                                <input className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline" id="companyPassword" type="password" placeholder="Please select a password between 8-16 characters" onChange={this.handleChange}/>
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
