import { useContext, useEffect, useState } from "react";
import "./Register.css";
import { Link, useNavigate } from "react-router-dom";
import { GlobalContext } from "../../provide";

const Register = () => {
  const navigation = useNavigate();
  const [data, setData] = useState({
    username: "",
    password: "",
    email: "",
    name: "",
    phoneNumber: "",
  });
  const [errors, setErrors] = useState({});
  const loginContext = useContext(GlobalContext);
  const { setIsLogin, setUserInformation, isLogin } = loginContext;

  const handleRegisterFunction = async (e) => {
    e.preventDefault();
    try {
      if (validateForm()) {
        alert("Đăng ký thành công");
        // Điều hướng tới trang chính sau khi đăng ký thành công
        navigation("/");
      }
    } catch (err) {
      console.error(err);
    }
  };

  const validateForm = () => {
    let errors = {};
    let formIsValid = true;

    if (!data.username) {
      formIsValid = false;
      errors["username"] = "Vui lòng nhập tên người dùng";
    }

    if (!data.password) {
      formIsValid = false;
      errors["password"] = "Vui lòng nhập mật khẩu";
    }

    if (!data.email) {
      formIsValid = false;
      errors["email"] = "Vui lòng nhập địa chỉ email";
    }

    if (!data.name) {
      formIsValid = false;
      errors["name"] = "Vui lòng nhập tên";
    }

    if (!data.phoneNumber) {
      formIsValid = false;
      errors["phoneNumber"] = "Vui lòng nhập số điện thoại";
    }

    setErrors(errors);
    return formIsValid;
  };

  useEffect(() => {
    if (isLogin) {
      navigation("/");
    }
  }, [isLogin]);

  return (
    <div className={"registersform"}>
      <div className="flexsForm">
        <h1>Sign Up</h1>
        <div className="dividerSocial"></div>
        <form>
          <div className="textField">
            <label>Name</label>
            <input
              onChange={(e) => {
                setData({ ...data, name: e.target.value });
              }}
            />
            <span className="error">{errors["name"]}</span>
          </div>
          <div className="textField">
            <label>User name</label>
            <input
              onChange={(e) => {
                setData({ ...data, username: e.target.value });
              }}
            />
            <span className="error">{errors["username"]}</span>
          </div>
          <div className="textField">
            <label>Email</label>
            <input
              onChange={(e) => {
                setData({ ...data, email: e.target.value });
              }}
            />
            <span className="error">{errors["email"]}</span>
          </div>
          <div className="textField">
            <label>Password</label>
            <input
              type="password"
              onChange={(e) => {
                setData({ ...data, password: e.target.value });
              }}
            />
            <span className="error">{errors["password"]}</span>
          </div>
          <div className="textField">
            <label>Phone Number</label>
            <input
              type="text"
              pattern="[0-9]*"
              onChange={(e) => {
                const value = e.target.value.replace(/\D/g, "");
                setData({ ...data, phoneNumber: value });
              }}
            />
            <span className="error">{errors["phoneNumber"]}</span>
          </div>
          <button onClick={(e) => handleRegisterFunction(e)}>SIGN UP</button>
        </form>
      </div>
      <span className="divider"></span>
      <div className="loginsForm">
        <h3>Already have an account!</h3>
        <Link to={"/login"}>
          <button className="registerButton">SIGN IN HERE</button>
        </Link>
      </div>
    </div>
  );
};

export default Register;