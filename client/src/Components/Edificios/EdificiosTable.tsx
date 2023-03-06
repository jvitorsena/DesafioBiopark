import {
    Button,
    createStyles,
    IconButton,
    makeStyles,
    Paper,
    Snackbar,
    Table,
    TableBody,
    TableCell,
    TableContainer,
    TableHead,
    TableRow,
    Theme,
    Typography,
    TablePagination,
} from "@mui/material";
import {
    ITodosEdificios,
    TodosEdificios,
    EdificiosCabecalho,
    ExcluirEdificio
} from "../../Config/edificios";
import { Delete, Edit } from "@mui/icons-material";
import React, { useEffect, useState } from "react";
// import axios from 'axios';
// import moment from 'moment';
import { ThemeProvider, createTheme } from "@mui/material/styles";
import moment from "moment";
import { TrashIcon } from "../Icons";
import EdificiosEditModal from "./EdificiosEditModal";
import ErrorModal from "../ErrorModal";

const darkTheme = createTheme({
    typography: {
        fontSize: 14,
    },
    components: {},
    palette: {
        mode: "dark",
    },
});

interface props {
    values: Array<ITodosEdificios>;
    quantityValues: number;
    setTodosEdificios: React.Dispatch<React.SetStateAction<Array<ITodosEdificios>>>
}

export default function EdificiosTable(props: props) {
    const [open, setOpen] = React.useState(false);
    const [page, setPage] = React.useState(0);
    const [rowsPerPage, setRowsPerPage] = React.useState(10);
    const [errMsg, setErrMsg] = React.useState('');

    const handleChangePage = (event: unknown, newPage: number) => {
        setPage(newPage);
    };

    const handleChangeRowsPerPage = (
        event: React.ChangeEvent<HTMLInputElement>
    ) => {
        setRowsPerPage(+event.target.value);
        setPage(0);
    };

    function DeletarEdificio(id: number) {
        ExcluirEdificio(id).then(() => reload()).catch((error) => { setOpen(true), setErrMsg(error.response.data) });
    }

    const reload = async () => {
        await TodosEdificios.then((json) => window.location.reload()).catch((error) =>
            console.log(error)
        );
        console.log("eoeo")
    }

    return (
        <>
            <ThemeProvider theme={darkTheme}>
                <ErrorModal setOpen={setOpen} open={open} errMsg={errMsg} />
                {/* <a className='cursor-pointer' onClick={() => teste2()}>saodjaoid</a> */}
                <TableContainer>
                    <Table>
                        <TableRow>
                            {EdificiosCabecalho.map((value) => (
                                <TableCell>{value}</TableCell>
                            ))}
                        </TableRow>
                        <TableBody>
                            {props.values
                                .slice(page * rowsPerPage, page * rowsPerPage + rowsPerPage)
                                .map((value) => (
                                    <TableRow>
                                        <TableCell component="th" scope="row">
                                            {value.id}
                                        </TableCell>
                                        <TableCell component="th" scope="row">
                                            {value.nome}
                                        </TableCell>
                                        <TableCell component="th" scope="row">
                                            {value.locadora}
                                        </TableCell>
                                        <TableCell component="th" scope="row">
                                            {moment(value.createdAt).format("DD/MM/YYYY")}
                                        </TableCell>
                                        <TableCell component="th" scope="row">
                                            {moment(value.updatedAt).format("DD/MM/YYYY")}
                                        </TableCell>
                                        <TableCell component="th" scope="row">
                                            {value.isActive ? "Ativo" : "Inativo"}
                                        </TableCell>
                                        <TableCell component="th" scope="row">
                                            <div className="flex flex-row items-center whitespace-nowrap text-right text-sm font-medium">
                                                <EdificiosEditModal id={value.id} locadora={value.locadora} nome={value.nome} />
                                                <a className="mx-1" href="#" onClick={() => DeletarEdificio(value.id)}>
                                                    {TrashIcon}
                                                </a>
                                            </div>
                                        </TableCell>
                                    </TableRow>

                                ))}
                        </TableBody>
                    </Table>
                </TableContainer>
            </ThemeProvider>
            <TablePagination
                rowsPerPageOptions={[10, 25, 100]}
                component="div"
                count={props.quantityValues}
                rowsPerPage={rowsPerPage}
                page={page}
                onPageChange={handleChangePage}
                onRowsPerPageChange={handleChangeRowsPerPage}
            />
        </>
    );
}
