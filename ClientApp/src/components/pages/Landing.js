import React, { Component } from 'react'
import {NavLink} from 'react-router-dom'
import SignedOutLinks from '../layout/SignedOutLinks'

export default class Landing extends Component {
    render() {
        return (
            <div>
            <SignedOutLinks/>
            <div className="bg-cover-teal-100">
                <p className=" text-3xl italic bg-teal-100 text-center text-gray-600 pt-10 pb-10">
                    Our mission is to provide quality menu options to Employees of Small Businesses
                    that are unable to house their own cafeteria. This online system allows users to order
                    dishes from a variety of menu items and be delivered to their company premises.
                </p>
                <div className="flex bg-teal-100 p-3">
                    <div className="flex-1 text-gray-700 text-3xl font-bold text-center bg-green-400 px-4 py-2 m-2">
                        Company Registration
                        <p className="text-xl font-normal pt-3 pb-3">
                        Click here to register your company on our system so your employees can enjoy a first class cafeteria experience.
                        </p>
                        <NavLink to='/company-registration' className="text-xl bg-orange-500 hover:bg-orange-300 text-white font-bold py-2 px-4 border border-blue-700 rounded">
                            Register Company
                        </NavLink>
                    </div>
                    <div className="flex-1 text-gray-700 text-3xl font-bold text-center bg-red-400 px-4 py-2 m-2">
                        Employee Registration
                        <p className="text-xl font-normal pt-3 pb-3">
                        Click here to register with your company provided code so that you can enjoy Online Cafeteria System meals.
                        </p>
                        <NavLink to='/employee-registration' className="text-xl bg-orange-500 hover:bg-orange-300 text-white font-bold py-2 px-4 border border-blue-700 rounded">
                            Register Employee
                        </NavLink>
                    </div>
                </div>                
            </div>
            </div>
        )
    }
}