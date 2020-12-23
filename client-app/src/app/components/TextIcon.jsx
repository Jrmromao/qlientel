import React, { Component } from "react";
import PropTypes from "prop-types";
import { Icon, Popup } from "semantic-ui-react";

export default class TextIcon extends Component {
  static propTypes = {
    name: PropTypes.string.isRequired,
    hideText: PropTypes.bool.isRequired,
    color: PropTypes.string,
    size: PropTypes.string.isRequired,
    inverted: PropTypes.bool,
    colorTxt: PropTypes.string,
    toolTipContent: PropTypes.string
  };

  style = {
    alignSelf: "center",
    paddingLeft: "5px",
    color: this.props.colorTxt ? this.props.colorTxt : "#000",
  };

   styleTT = {
    borderRadius: 0,
    padding: '2em',
  }
  render() {
    return (
      <div style={{ display: "inline-flex" }}>
        <Popup
        disabled={!this.props.hideText}
        style={this.styleTT}
          trigger={
        <Icon
          size={this.props.size}
          inverted={this.props.inverted}
          color={this.props.color}
          name={this.props.name}
        />}
        content={this.props.toolTipContent}
        position='right center'
      />
        <div
          style={this.style}
          hidden={this.props.hideText}
          color={this.props.colorTxt}
        >
          {this.props.children}
        </div>
      </div>
    );
  }
}
