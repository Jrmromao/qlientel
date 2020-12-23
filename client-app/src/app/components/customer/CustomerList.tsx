import React from "react";
import { Link } from "react-router-dom";
import { Button, Icon, Menu, Search, Table } from "semantic-ui-react";
import { v4 as uuidv4 } from 'uuid';
const CustomerList: React.FC = () => {
  return (
    <div>
<Search/>


      <Table basic='very'>
        <Table.Header>
          <Table.Row>
            <Table.HeaderCell>Name</Table.HeaderCell>
            <Table.HeaderCell>Date Registered</Table.HeaderCell>
            <Table.HeaderCell>E-mail</Table.HeaderCell>
            <Table.HeaderCell />
          </Table.Row>
        </Table.Header>

        <Table.Body>
          <Table.Row>
            <Table.Cell>H&M</Table.Cell>
            <Table.Cell>January 11, 2014</Table.Cell>
            <Table.Cell>jill.kendu@hm.com</Table.Cell>
            <Table.Cell>
            <Button color='yellow' labelPosition='left' icon='eye'  as={Link} to={`/customer/${uuidv4()}`} content="View" />
            </Table.Cell>
          </Table.Row>
          <Table.Row>
            <Table.Cell>Dunnes Stores</Table.Cell>
            <Table.Cell>January 11, 2014</Table.Cell>
            <Table.Cell>jamieharingonton@yahoo.com</Table.Cell>
            <Table.Cell>
              <Button color='yellow' labelPosition='left' icon='eye' as={Link} to={`/customer/${uuidv4()}`} content="View" />
            </Table.Cell>
          </Table.Row>
          <Table.Row>
            <Table.Cell>Aldi Ltd</Table.Cell>
            <Table.Cell>January 11, 2014</Table.Cell>
            <Table.Cell>jamieharingonton@yahoo.com</Table.Cell>
            <Table.Cell>
            <Button color='yellow' labelPosition='left' icon='eye'  as={Link} to={`/customer/${uuidv4()}`} content="View" />
            </Table.Cell>
          </Table.Row>
          <Table.Row>
            <Table.Cell>Zara Ltd</Table.Cell>
            <Table.Cell>May 11, 2014</Table.Cell>
            <Table.Cell>jilsewris22@yahoo.com</Table.Cell>
            <Table.Cell>
            <Button color='yellow' labelPosition='left' icon='eye'  as={Link} to={`/customer/${uuidv4()}`} content="View" />
            </Table.Cell>
          </Table.Row>
          <Table.Row>
            <Table.Cell>Tesco Inc</Table.Cell>
            <Table.Cell>September 14, 2013</Table.Cell>
            <Table.Cell>jhlilk22@yahoo.com</Table.Cell>
            <Table.Cell>
            <Button color='yellow' labelPosition='left' icon='eye'  as={Link} to={`/customer/${uuidv4()}`} content="View" />
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
    </div>
  );
};

export default CustomerList;
