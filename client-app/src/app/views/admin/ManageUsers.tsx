import { observer } from 'mobx-react-lite';
import React from 'react'
import UsersList from '../../components/user/UsersList';
import ManageEmployeeLayout from '../../layout/admin/ManageEmployeeLayout'


const ManageUsers = () => {
  return (
    <ManageEmployeeLayout>
      <div>
   
        <UsersList />
      </div>
    </ManageEmployeeLayout>
  );
};

export default observer(ManageUsers);
