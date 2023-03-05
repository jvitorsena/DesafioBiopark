import { useState } from "react";
interface props {
  route: string;
  setRoute: any;
}

export default function Asidebar(props: props) {
  return (
    <>
      <aside
        className={`dark:bg-[#1E1F25] dark:text-white group hidden md:flex md:flex-col h-screen py-5 pt-8 bg-surface-default transition-all duration-700 ease-in-out relative md:w-40 lg:w-52`}
      >
        <div className="mt-8 flex flex-col overflow-y-auto">
          <nav className="mt-6">
            <div className="space-y-3">
              <a
                className="group flex items-center px-4 py-2 dark:hover:bg-[#262833] relative text-midnight-primary font-semibold cursor-pointer"
                onClick={() => props.setRoute("edificios")}
              >
                {props.route == "edificios" ? (
                  <div className="hidden md:inline-block h-5 w-0.5 bg-midnight-primary absolute right-0 dark:bg-white" />
                ) : null}

                <div className="flex justify-center items-center mr-2">
                  <svg
                    className="h-5 w-5 stroke-midnight-primary"
                    width="20"
                    height="20"
                    viewBox="0 0 20 20"
                    fill="none"
                    xmlns="http://www.w3.org/2000/svg"
                  >
                    <path
                      d="M10 10L17.5 10M10 2.5L10 17.5M6.5 2.5H13.5C14.9001 2.5 15.6002 2.5 16.135 2.77248C16.6054 3.01217 16.9878 3.39462 17.2275 3.86502C17.5 4.3998 17.5 5.09987 17.5 6.5V13.5C17.5 14.9001 17.5 15.6002 17.2275 16.135C16.9878 16.6054 16.6054 16.9878 16.135 17.2275C15.6002 17.5 14.9001 17.5 13.5 17.5H6.5C5.09987 17.5 4.3998 17.5 3.86502 17.2275C3.39462 16.9878 3.01217 16.6054 2.77248 16.135C2.5 15.6002 2.5 14.9001 2.5 13.5V6.5C2.5 5.09987 2.5 4.3998 2.77248 3.86502C3.01217 3.39462 3.39462 3.01217 3.86502 2.77248C4.3998 2.5 5.09987 2.5 6.5 2.5Z"
                      stroke-width="1.5"
                      stroke-linecap="round"
                      stroke-linejoin="round"
                    ></path>
                  </svg>
                </div>
                <span className="truncate">Edificios</span>
              </a>
            </div>
            <div className="space-y-3">
              <a
                className="group flex items-center px-4 py-2 dark:hover:bg-[#262833] relative text-midnight-primary font-semibold cursor-pointer"
                onClick={() => props.setRoute("apartamentos")}
              >
                {props.route == "apartamentos" ? (
                  <div className="hidden md:inline-block h-5 w-0.5 bg-midnight-primary absolute right-0 dark:bg-white" />
                ) : null}
                <div className="flex justify-center items-center mr-2">
                  <svg
                    className="h-5 w-5 stroke-midnight-primary"
                    width="20"
                    height="20"
                    viewBox="0 0 20 20"
                    fill="none"
                    xmlns="http://www.w3.org/2000/svg"
                  >
                    <path
                      d="M10 10L17.5 10M10 2.5L10 17.5M6.5 2.5H13.5C14.9001 2.5 15.6002 2.5 16.135 2.77248C16.6054 3.01217 16.9878 3.39462 17.2275 3.86502C17.5 4.3998 17.5 5.09987 17.5 6.5V13.5C17.5 14.9001 17.5 15.6002 17.2275 16.135C16.9878 16.6054 16.6054 16.9878 16.135 17.2275C15.6002 17.5 14.9001 17.5 13.5 17.5H6.5C5.09987 17.5 4.3998 17.5 3.86502 17.2275C3.39462 16.9878 3.01217 16.6054 2.77248 16.135C2.5 15.6002 2.5 14.9001 2.5 13.5V6.5C2.5 5.09987 2.5 4.3998 2.77248 3.86502C3.01217 3.39462 3.39462 3.01217 3.86502 2.77248C4.3998 2.5 5.09987 2.5 6.5 2.5Z"
                      stroke-width="1.5"
                      stroke-linecap="round"
                      stroke-linejoin="round"
                    ></path>
                  </svg>
                </div>
                <span className="truncate">Apartamentos</span>
              </a>
            </div>
            <div className="space-y-3">
              <a
                className="group flex items-center px-4 py-2 dark:hover:bg-[#262833] relative text-midnight-primary font-semibold cursor-pointer"
                onClick={() => props.setRoute("locatarios")}
              >
                {props.route == "locatarios" ? (
                  <div className="hidden md:inline-block h-5 w-0.5 bg-midnight-primary absolute right-0 dark:bg-white" />
                ) : null}
                <div className="flex justify-center items-center mr-2">
                  <svg
                    className="h-5 w-5 stroke-midnight-primary"
                    width="20"
                    height="20"
                    viewBox="0 0 20 20"
                    fill="none"
                    xmlns="http://www.w3.org/2000/svg"
                  >
                    <path
                      d="M10 10L17.5 10M10 2.5L10 17.5M6.5 2.5H13.5C14.9001 2.5 15.6002 2.5 16.135 2.77248C16.6054 3.01217 16.9878 3.39462 17.2275 3.86502C17.5 4.3998 17.5 5.09987 17.5 6.5V13.5C17.5 14.9001 17.5 15.6002 17.2275 16.135C16.9878 16.6054 16.6054 16.9878 16.135 17.2275C15.6002 17.5 14.9001 17.5 13.5 17.5H6.5C5.09987 17.5 4.3998 17.5 3.86502 17.2275C3.39462 16.9878 3.01217 16.6054 2.77248 16.135C2.5 15.6002 2.5 14.9001 2.5 13.5V6.5C2.5 5.09987 2.5 4.3998 2.77248 3.86502C3.01217 3.39462 3.39462 3.01217 3.86502 2.77248C4.3998 2.5 5.09987 2.5 6.5 2.5Z"
                      stroke-width="1.5"
                      stroke-linecap="round"
                      stroke-linejoin="round"
                    ></path>
                  </svg>
                </div>
                <span className="truncate">Locatarios</span>
              </a>
            </div>
            <div className="space-y-3">
              <a
                className="group flex items-center px-4 py-2 dark:hover:bg-[#262833] relative text-midnight-primary font-semibold cursor-pointer"
                onClick={() => props.setRoute("alugueis")}
              >
                {props.route == "alugueis" ? (
                  <div className="hidden md:inline-block h-5 w-0.5 bg-midnight-primary absolute right-0 dark:bg-white" />
                ) : null}
                <div className="flex justify-center items-center mr-2">
                  <svg
                    className="h-5 w-5 stroke-midnight-primary"
                    width="20"
                    height="20"
                    viewBox="0 0 20 20"
                    fill="none"
                    xmlns="http://www.w3.org/2000/svg"
                  >
                    <path
                      d="M10 10L17.5 10M10 2.5L10 17.5M6.5 2.5H13.5C14.9001 2.5 15.6002 2.5 16.135 2.77248C16.6054 3.01217 16.9878 3.39462 17.2275 3.86502C17.5 4.3998 17.5 5.09987 17.5 6.5V13.5C17.5 14.9001 17.5 15.6002 17.2275 16.135C16.9878 16.6054 16.6054 16.9878 16.135 17.2275C15.6002 17.5 14.9001 17.5 13.5 17.5H6.5C5.09987 17.5 4.3998 17.5 3.86502 17.2275C3.39462 16.9878 3.01217 16.6054 2.77248 16.135C2.5 15.6002 2.5 14.9001 2.5 13.5V6.5C2.5 5.09987 2.5 4.3998 2.77248 3.86502C3.01217 3.39462 3.39462 3.01217 3.86502 2.77248C4.3998 2.5 5.09987 2.5 6.5 2.5Z"
                      stroke-width="1.5"
                      stroke-linecap="round"
                      stroke-linejoin="round"
                    ></path>
                  </svg>
                </div>
                <span className="truncate">Aluguéis</span>
              </a>
            </div>
          </nav>
        </div>
      </aside>
    </>
  );
}
