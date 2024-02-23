import { createContext, useEffect, useState } from "react";

export const GlobalContext = createContext();

function GlobalProvider({ children }) {
  const [isLogin, setIsLogin] = useState(
    () => JSON.parse(sessionStorage.getItem("isLogin")) || false
  );

  useEffect(() => {
    sessionStorage.setItem("isLogin", JSON.stringify(isLogin));
  }, [isLogin]);

  return (
    <GlobalContext.Provider value={{ isLogin, setIsLogin }}>
      {children}
    </GlobalContext.Provider>
  );
}

export default GlobalProvider;
