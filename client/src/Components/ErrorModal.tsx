import * as React from 'react';
import Box from '@mui/material/Box';
import Button from '@mui/material/Button';
import Typography from '@mui/material/Typography';
import Modal from '@mui/material/Modal';

const style = {
    position: 'absolute' as 'absolute',
    top: '50%',
    left: '50%',
    transform: 'translate(-50%, -50%)',
    width: 400,
    bgcolor: 'background.paper',
    boxShadow: 24,
    p: 4,
};

interface props {
    setOpen: React.Dispatch<React.SetStateAction<boolean>>;
    open: boolean;
    errMsg: string;
}

export default function ErrorModal(props: props) {
    const handleOpen = () => props.setOpen(true);
    const handleClose = () => props.setOpen(false);

    return (
        <div>
            {/* <Button onClick={handleOpen}>Open modal</Button> */}
            <Modal
                open={props.open}
                onClose={handleClose}
                aria-labelledby="modal-modal-title"
                aria-describedby="modal-modal-description"
            >
                <Box sx={style}>
                    <div className='dark:text-white'>
                        <Typography id="modal-modal-title" variant="h6" component="h2">
                            {props.errMsg}
                        </Typography>
                    </div>
                </Box>
            </Modal>
        </div>
    );
}