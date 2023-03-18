import * as React from 'react';
import Box from '@mui/material/Box';
import Modal from '@mui/material/Modal';
import Button from '@mui/material/Button';
import TextField from '@mui/material/TextField';
import { NovoAluguel } from '../../Config/alugueis';
import { TodosApartamentos, ITodosApartamentos } from '../../Config/apartamentos';
import { TodosLocatarios, ITodosLocatarios } from '../../Config/locatarios';
import MenuItem from '@mui/material/MenuItem';
import { useEffect } from 'react';
import { ITodosEdificios, TodosEdificios } from '../../Config/edificios';

const style = {
    position: 'absolute' as 'absolute',
    top: '50%',
    left: '50%',
    transform: 'translate(-50%, -50%)',
    width: 400,
    bgcolor: 'background.paper',
    border: '2px solid #000',
    boxShadow: 24,
    pt: 2,
    px: 4,
    pb: 3,
};

function ChildModal() {
    const [open, setOpen] = React.useState(false);


    const handleOpen = () => {
        setOpen(true);
    };
    const handleClose = () => {
        setOpen(false);
    };



    return (
        <React.Fragment>
            <Button onClick={handleOpen}>Open Child Modal</Button>
            <Modal
                open={open}
                onClose={handleClose}
                aria-labelledby="child-modal-title"
                aria-describedby="child-modal-description"
            >
                <Box sx={{ ...style, width: 200 }}>
                    <h2 id="child-modal-title">Text in a child modal</h2>
                    <p id="child-modal-description">
                        Lorem ipsum, dolor sit amet consectetur adipisicing elit.
                    </p>
                    <Button onClick={handleClose}>Close Child Modal</Button>
                </Box>
            </Modal>
        </React.Fragment>
    );
}

export default function AluguelNovoModal() {
    const [open, setOpen] = React.useState(false);

    const [locatarios, setTodosLocatarios] = React.useState<Array<ITodosLocatarios>>([]);
    const [apartamentos, setTodosApartamentos] = React.useState<Array<ITodosApartamentos>>([]);
    const [edificios, setEdificios] = React.useState<Array<ITodosEdificios>>([]);

    const [apartamentoId, setApartamentoId] = React.useState<number>(0);
    const [locatarioId, setLocatarioId] = React.useState<number>(0);
    const [valorAluguelMen, setValorAluguelMen] = React.useState<number>(0);
    const [edificioId, setEdificioId] = React.useState<number>(0);

    useEffect(() => {
        TodosApartamentos.then((json) => setTodosApartamentos(json)).catch((error) =>
            console.log(error)
        );
        TodosLocatarios.then((json) => setTodosLocatarios(json)).catch((error) =>
            console.log(error)
        );
        TodosEdificios.then((json) => setEdificios(json)).catch((error) => console.log(error));
    }, []);

    function register() {
        NovoAluguel(valorAluguelMen, locatarioId, apartamentoId).then((response) => { window.location.reload(); }).catch((error) => console.log(error));
    }

    const handleOpen = () => {
        setOpen(true);
    };
    const handleClose = () => {
        setOpen(false);
    };

    return (
        <div>
            <Button onClick={handleOpen}>Novo aluguel</Button>
            <Modal
                open={open}
                onClose={handleClose}
                aria-labelledby="parent-modal-title"
                aria-describedby="parent-modal-description"
            >
                <Box sx={{ ...style, width: 400 }}>
                    <div>
                        <TextField type='number' id="standard-basic" label="Valor aluguel" variant="standard" onChange={(e) => setValorAluguelMen(Number(e.target.value))} />
                    </div>
                    <div className='mt-5'>
                        <TextField
                            id="outlined-select-currency"
                            select
                            label="Locatarios"
                            defaultValue="EUR"
                            helperText="Selecione o locatario"
                            onChange={(e) => setLocatarioId(Number(e.target.value))}
                            value={locatarioId}
                        >
                            {locatarios
                                .filter((value) => value.isActive === true)
                                .map((value) => (
                                    <MenuItem key={value.id} value={value.id}>
                                        {value.nome}
                                    </MenuItem>
                                ))}
                        </TextField>
                    </div>
                    <div className='mt-5'>
                        <TextField
                            id="outlined-select-currency"
                            select
                            label="Edificios"
                            defaultValue="0"
                            helperText="Selecione o edificio"
                            onChange={(e) => { setEdificioId(Number(e.target.value)); setApartamentoId(0); console.log(apartamentoId) }}
                            aria-disabled={true}
                            value={edificioId}
                        >
                            {edificios
                                .filter((value) => value.isActive === true)
                                .map((value) => (
                                    <MenuItem key={value.id} value={value.id}>
                                        {value.nome}
                                    </MenuItem>
                                ))}
                        </TextField>
                    </div>
                    <div className='mt-5'>
                        <TextField
                            id="outlined-select-currency"
                            select
                            label="Apartamentos"
                            defaultValue="EUR"
                            helperText="Selecione o apartamento"
                            onChange={(e) => setApartamentoId(Number(e.target.value))}
                            disabled={edificioId === 0 ? true : false}
                            value={apartamentoId}
                        >
                            {apartamentos
                                .filter((value) => value.isActive === true && value.alugado === false && value.edificiosId === edificioId)
                                .map((value) => (
                                    <MenuItem key={value.id} value={value.id}>
                                        {value.numero}
                                    </MenuItem>
                                ))}
                        </TextField>
                    </div>
                    <div className='mt-5'>
                        <Button onClick={() => register()}>Criar</Button>
                        {/* <ChildModal /> */}
                    </div>

                </Box>
            </Modal>
        </div>
    );
}
