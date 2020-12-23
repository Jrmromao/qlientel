import React from 'react'
import AdminLayout from './adminLayout'

const ProfileLayout:React.FC<{children: any}> = ({children}) => {
    return <AdminLayout>{children}</AdminLayout>;
}

export default ProfileLayout
