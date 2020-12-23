import React from 'react'
import { Link } from 'react-router-dom';
import { Button, Header, Icon, Menu, Search, Segment, Table } from "semantic-ui-react";
import { v4 as uuidv4 } from "uuid";

const UsersList = () => {
    return (
      <Segment>
        <Header  content="User List" />
        <Search />
        <Table
          basic="very"
          striped
          className="user-list"
          columns="3"
        >
          <Table.Header>
            <Table.Row>
              <Table.HeaderCell content="Name" />
              <Table.HeaderCell content="Email" />
              <Table.HeaderCell content="Role" />
              <Table.HeaderCell />
            </Table.Row>
          </Table.Header>
          <Table.Body>
            <Table.Row>
              <Table.Cell content="Julios Mokoko" />
              <Table.Cell content="julios.mokoko@mcpit.ie" />
              <Table.Cell content="Admin" />
              <Table.Cell className='actions' >
                <Button
                  color="yellow"
                  as={Link}
                  to={`/view-user/${uuidv4()}`}
                  icon="eye"
                />
               
                <Button
                  icon="redo"
                  primary
                  as={Link}
                  to={`/update-user/${uuidv4()}`}
                />
                <Button
                  icon="trash"
                  color='red'
                  as={Link}
                  to={`/update-user/${uuidv4()}`}
                />
              </Table.Cell>
            </Table.Row>

            <Table.Row>
              <Table.Cell content="Kim Parnassian" />
              <Table.Cell content="kim.par@mcpit.ie" />
              <Table.Cell content="User" />
              <Table.Cell className='actions' >
              <Button
                  color="yellow"
                  as={Link}
                  to={`/view-user/${uuidv4()}`}
                  icon="eye"
                />
               
                <Button
                  icon="redo"
                  primary
                  as={Link}
                  to={`/update-user/${uuidv4()}`}
                />
                <Button
                  icon="trash"
                  color='red'
                  as={Link}
                  to={`/update-user/${uuidv4()}`}
                />
              </Table.Cell>
            </Table.Row>
            <Table.Row>
              <Table.Cell content="Joaquim Parma" />
              <Table.Cell content="joaquim.par@mcpit.ie" />
              <Table.Cell content="Manager" />
              <Table.Cell className='actions' >
              <Button
                  color="yellow"
                  as={Link}
                  to={`/view-user/${uuidv4()}`}
                  icon="eye"
                />
               
                <Button
                  icon="redo"
                  primary
                  as={Link}
                  to={`/update-user/${uuidv4()}`}
                />
                <Button
                  icon="trash"
                  color='red'
                  as={Link}
                  to={`/update-user/${uuidv4()}`}
                />
              </Table.Cell>
            </Table.Row>
            <Table.Row>
              <Table.Cell content="James Marcus" />
              <Table.Cell content="james.marcus@mcpit.ie" />
              <Table.Cell content="User" />
              <Table.Cell className='actions' >
               <Button
                  color="yellow"
                  as={Link}
                  to={`/view-user/${uuidv4()}`}
                  icon="eye"
                />
               
                <Button
                  icon="redo"
                  primary
                  as={Link}
                  to={`/update-user/${uuidv4()}`}
                />
                <Button
                  icon="trash"
                  color='red'
                  as={Link}
                  to={`/update-user/${uuidv4()}`}
                />
              </Table.Cell>
            </Table.Row>
          </Table.Body>

          <Table.Footer>
            <Table.Row>
              <Table.HeaderCell colSpan="3">
                <Menu pagination>
                  <Menu.Item as="a" icon>
                    <Icon name="chevron left" />
                  </Menu.Item>
                  <Menu.Item as="a">1</Menu.Item>
                  <Menu.Item as="a">2</Menu.Item>
                  <Menu.Item as="a">3</Menu.Item>
                  <Menu.Item as="a">4</Menu.Item>
                  <Menu.Item as="a" icon>
                    <Icon name="chevron right" />
                  </Menu.Item>
                </Menu>
              </Table.HeaderCell>
              <Table.HeaderCell />
            </Table.Row>
          </Table.Footer>
        </Table>
      </Segment>
    );
}

export default UsersList
