import { useState, useEffect } from "react";
import { ITodosEdificios, TodosEdificios } from "../../Config/edificios";
import {
  InputLabel,
  MenuItem,
  FormControl,
  TextField,
  FormLabel,
  RadioGroup,
  FormControlLabel,
  Radio,
} from "@mui/material";
import Select, { SelectChangeEvent } from "@mui/material/Select";
import { teste } from "../../Config/edificios";

export default function EdificiosContent() {
  const [selectDocuments, setSelectDocuments] = useState("0");
  const [todosEdificios, setTodosEdificios] = useState<Array<ITodosEdificios>>(
    []
  );

  useEffect(() => {
    TodosEdificios.then((json) => setTodosEdificios(json)).catch((error) =>
      console.log(error)
    );
  }, []);

  const handleChange = (event: SelectChangeEvent, idSelect: string) => {
    setSelectDocuments(event.target.value as string);
  };

  return (
    <>
      <div className="mt-5">
        <div className="w-full">
          <div className="rounded-2xl py-5 px-4 sm:px-6 bg-surface-default bg-[#1E1F25]">
            <div className="grid gap-3 grid-cols-4 sm:flex flex-wrap justify-between items-center">
              <div className="col-span-4 flex justify-between">
                <div className="flex items-center space-x-3">
                  <div className="font-semibold text-xl dark:text-white">
                    Pagina inicial
                  </div>
                  <FormControl fullWidth>
                    <InputLabel id="demo-simple-select-label">
                      Document
                    </InputLabel>
                    <Select
                      labelId="Document"
                      id="Document"
                      defaultValue="Document"
                      value={selectDocuments}
                      label="Document"
                      onChange={(a) => handleChange(a, "documents")}
                    >
                      <MenuItem value={"0"}>Select</MenuItem>
                      <MenuItem value={"2022"}>2022</MenuItem>
                      <MenuItem value={"2023"}>2023</MenuItem>
                    </Select>
                  </FormControl>
                </div>
              </div>
              <div className="col-span-4 sm:flex space-y-3 sm:space-y-0 sm:space-x-3">
                <div className="sm:flex hidden"></div>
                <div className="flex p-0.5 sm:space-x-3 rounded-full sm:max-w-md transition-colors">
                  {/* <NewAccountModal onPressReload={Reload} /> */}
                </div>
              </div>
            </div>
            <div className="mt-2 dark:text-white">
              <div className="rounded-xl mt-7 focus:outline-none">
                <div className="flex flex-col -mx-4 sm:mx-0">
                  <div className="overflow-visible dark:border-slate-700 rounded-xl">
                    <h1>Hello World</h1>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </>
  );
}
