import { useState, useEffect } from "react";
import { ITodosApartamentos, TodosApartamentos } from "../../Config/apartamentos";
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
import AlugueisTable from "./AlugueisTable";
import AluguelNovoModal from "./AlugueisNovoModal";
import { ITodosAlugueis, TodosAlugueis } from "../../Config/alugueis";
import { ITodosEdificios, TodosEdificios } from "../../Config/edificios";

export default function AlugueisContent() {
    const [selectDocuments, setSelectDocuments] = useState("0");
    const [todosAlugueis, setTodosAlugueis] = useState<Array<ITodosAlugueis>>(
        []
    );

    useEffect(() => {
        TodosAlugueis.then((json) => setTodosAlugueis(json)).catch((error) =>
            console.log(error)
        );
    }, []);

    function teste() {
        TodosAlugueis.then((json) => setTodosAlugueis(json)).catch((error) =>
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
                                    < AluguelNovoModal />
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
                                        <AlugueisTable
                                            values={todosAlugueis.filter((aluguel) => aluguel.isActive === true)}
                                            quantityValues={todosAlugueis.filter((aluguel) => aluguel.isActive === true).length}
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
