import React from "react";
import { Link } from "react-router-dom";
import { Button, Header, Icon, Menu, Segment, Table } from "semantic-ui-react";
import { v4 as uuidv4 } from "uuid";
const CustomerDocList = () => {
  return (
    <Segment>
      <Header content="Customer Documents" as="h3" />

      <Table basic="very" className="customer-document-list" columns="1">
        <Table.Header>
          <Table.Row>
            <Table.HeaderCell>Name</Table.HeaderCell>
            <Table.HeaderCell />
          </Table.Row>
        </Table.Header>
        <Table.Body>
          <Table.Row>
            <Table.Cell>Contact</Table.Cell>
            <Table.Cell>
              <Button
                  color='yellow'
                as={Link}
                icon='eye'
                labelPosition='left'
                to={`/customer/${uuidv4()}`}
                content="View"
              />
            </Table.Cell>
          </Table.Row>
          <Table.Row>
            <Table.Cell>October_report</Table.Cell>
            <Table.Cell>
            <Button
                  color='yellow'
                as={Link}
                icon='eye'
                labelPosition='left'
                to={`/customer/${uuidv4()}`}
                content="View"
              />
            </Table.Cell>
          </Table.Row>
          <Table.Row>
            <Table.Cell>containers_report</Table.Cell>

            <Table.Cell>
            <Button
                  color='yellow'
                as={Link}
                icon='eye'
                labelPosition='left'
                to={`/customer/${uuidv4()}`}
                content="View"
              />
            </Table.Cell>
          </Table.Row>
          <Table.Row>
            <Table.Cell>belgium_order</Table.Cell>

            <Table.Cell>
            <Button
                  color='yellow'
                as={Link}
                icon='eye'
                labelPosition='left'
                to={`/customer/${uuidv4()}`}
                content="View"
              />
            </Table.Cell>
          </Table.Row>
          <Table.Row>
            <Table.Cell>November_report</Table.Cell>

            <Table.Cell>
            <Button
                  color='yellow'
                as={Link}
                icon='eye'
                labelPosition='left'
                to={`/customer/${uuidv4()}`}
                content="View"
              />
            </Table.Cell>
          </Table.Row>
          <Table.Row>
            <Table.Cell>November_report</Table.Cell>

            <Table.Cell>
            <Button
                  color='yellow'
                as={Link}
                icon='eye'
                labelPosition='left'
                to={`/customer/${uuidv4()}`}
                content="View"
              />
            </Table.Cell>
          </Table.Row>
          <Table.Row>
            <Table.Cell>November_report</Table.Cell>

            <Table.Cell>
            <Button
                color='yellow'
                as={Link}
                icon='eye'
                labelPosition='left'
                to={`/customer/${uuidv4()}`}
                content="View"
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
};

export default CustomerDocList;
