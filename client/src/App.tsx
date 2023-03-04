import { useState } from "react";
import { ThemeProvider, createTheme } from "@mui/material/styles";
import Asidebar from "./Components/Asidebar";
import Head from "./Components/Head";
import EdificiosContent from "./Components/Edificios/EdificiosContent";

const darkTheme = createTheme({
  palette: {
    mode: "dark",
  },
});

export default function App() {
  const [route, setRoute] = useState<string>("edificios");

  return (
    <ThemeProvider theme={darkTheme}>
      <div>
        <div className="dark min-h-full bg-[#101213] flex max-h-screen">
          <Asidebar route={route} setRoute={setRoute} />
          <div className="flex flex-col min-h-screen w-full overflow-y-auto relative">
            <main className="flex-1 md:mx-4 my-4 lg:mx-8 lg:my-0">
              <div className="pb-10">
                <div className="bg-default px-4 pb-10 sm:px-10 sm:pt-8 sm:pb-12 lg:px-4">
                  <Head />
                  <EdificiosContent />
                  {/* {route == "initialPath" ? <Content /> : null}
                  {route == "Nubank" ? (
                    <TransactionContent name="Nubank" />
                  ) : null}
                  {route == "Nuconta" ? (
                    <TransactionContent name="Nuconta" />
                  ) : null} */}
                </div>
              </div>
            </main>
          </div>
        </div>
      </div>
    </ThemeProvider>
  );
}
