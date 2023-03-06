import { useState, useEffect } from "react";
import { TodosLocatarios, ITodosLocatarios } from "../../Config/locatarios";
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
    Button,
} from "@mui/material";
import Select, { SelectChangeEvent } from "@mui/material/Select";
import LocatariosTable from "./LocatariosTable";
import LocatarioNovoModal from "./LocatarioNovoModal";

export default function LocatariosConent() {
    const [selectDocuments, setSelectDocuments] = useState("0");
    const [todosLocatarios, setTodosLocatarios] = useState<Array<ITodosLocatarios>>(
        []
    );

    useEffect(() => {
        TodosLocatarios.then((json) => setTodosLocatarios(json)).catch((error) =>
            console.log(error)
        );
    }, []);

    function teste() {
        TodosLocatarios.then((json) => setTodosLocatarios(json)).catch((error) =>
            console.log(error)
        );
    }

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
                                    < LocatarioNovoModal />
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
                                        <LocatariosTable
                                            values={todosLocatarios.filter((value) => value.isActive === true)}
                                            quantityValues={todosLocatarios.filter((value) => value.isActive === true).length}
                                            setTodosEdificios={setTodosLocatarios}
                                        />
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
